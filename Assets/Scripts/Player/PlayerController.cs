using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private Transform _cameraTransform;
    private Rigidbody _rb;
    private Vector2 _moveInput;

    [Header("Raycast")]
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private float _raycastDistance = 5f;
    public RaycastHit hitInfo;

    [Header("Interact")]
    private Outline _currentOutline;
    [SerializeField] private IInteractable _currentInteractable;
    [SerializeField] private GameObject _interactTextObj;
    private TMP_Text _interactText;

    [Header("Item")]
    [SerializeField] private Transform _itemSpawnPoint;
    [SerializeField] private int _playerItemID;
    public bool hasItem = false;
    [SerializeField] private GameObject _currentItem;
    [SerializeField] private GameObject[] dropItemPrefabs;
    [SerializeField] private GameObject[] handItemObjects;

    
    


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _interactText = _interactTextObj.GetComponent<TMP_Text>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _CheckRaycast();
    }

    private void FixedUpdate()
    {
        _Movement();
    }

    private void _Movement()
    {
        Vector3 _moveDirection = _cameraTransform.forward * _moveInput.y + _cameraTransform.right * _moveInput.x;
        _moveDirection.y = 0f;
        _rb.linearVelocity = _moveDirection.normalized * _moveSpeed;
    }

    private void _CheckRaycast()
    {
        if (_IsRaycast())
        {
            Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * hitInfo.distance, Color.red);

            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
               _currentInteractable = interactObj;
                _interactTextObj.SetActive(true);
                _interactText.text = $"{interactObj.InteractText}";

            }
            else
            {
                _currentInteractable = null;
                _interactTextObj.SetActive(false);
            }

            if (hitInfo.collider.gameObject.TryGetComponent(out Outline newOutline))
            {
                if (_currentOutline != newOutline)
                {
                    if (_currentOutline != null)
                        _currentOutline.enabled = false;

                    _currentOutline = newOutline;
                    _currentOutline.enabled = true;
                }
            }
            else
            {
                if (_currentOutline != null)
                {
                    _currentOutline.enabled = false;
                    _currentOutline = null;

                }
            }

        }
        else
        {

            if (_currentOutline != null)
            {
                _currentOutline.enabled = false;
                _currentOutline = null;

            }

            _currentInteractable = null;

            _interactTextObj.SetActive(false);

            Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _raycastDistance, Color.green);
        }
    }

    //private void _SpawnBullet()
    //{
    //    var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
    //    var trailVFX = Instantiate(_vfxShootPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation, _bulletSpawnPoint);
    //    bullet.GetComponent<Rigidbody>().linearVelocity = _cameraTransform.forward * _bulletSpeed;
    //}

    public void AddItem(int itemID)
    {
        hasItem = true;
        _playerItemID = itemID;
        handItemObjects[itemID].SetActive(true);
        _currentItem = handItemObjects[itemID];

    }

    public void RemoveItem(int itemID)
    {
        if (!hasItem) return;
        _currentItem = null;    
        _currentInteractable = null;
        hasItem = false;
        handItemObjects[itemID].SetActive(false);
        Rigidbody rb = Instantiate(dropItemPrefabs[itemID], _itemSpawnPoint.position, _itemSpawnPoint.rotation).GetComponent<Rigidbody>();
        rb.AddForce(_cameraTransform.forward * 5f, ForceMode.Impulse);
    }



    private bool _IsRaycast()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        return Physics.Raycast(ray, out hitInfo, _raycastDistance, _layerMask);
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        RemoveItem(_playerItemID);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (!hasItem) return;
        
        if (_currentItem != null)
        {
            if (_currentItem.gameObject.TryGetComponent(out WeaponBase weaponBase))
            {
                weaponBase.Shoot();
            }
        }


    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (_currentItem != null)
        {
            if (_currentItem.gameObject.TryGetComponent(out WeaponBase weaponBase))
            {
                weaponBase.ReloadAmmo();
            }
        }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        Debug.Log("Key Preseed");

        if (_currentInteractable != null)
        {
            _currentInteractable?.Interact(this.gameObject);
        }
    }


}
