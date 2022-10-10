using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    
    
    private Camera _arCam;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private ARRaycastManager _raycastManager;
    private Transform _lastTarget;
    private Touch _touch;
    private Pose _pose;
    private Transform _parent;
    private GameOverTrigger _gameOverTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
        _arCam = GetComponentInChildren<Camera>();
        _parent = _arCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            Ray ray = _arCam.ScreenPointToRay(_touch.position);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Blocks"))
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                    Debug.Log(hit);

                    // Destroy(hit.transform.gameObject);

                    if (hit.transform != _lastTarget)
                    {
                        if (_lastTarget)
                        {
                            _lastTarget.parent = null;
                            _lastTarget.GetComponent<MeshRenderer>().material = defaultMaterial;
                            _lastTarget.GetComponent<Rigidbody>().isKinematic = false;
                        }

                        _lastTarget = hit.transform;
                    }

                    MeshRenderer renderer = hit.transform.GetComponent<MeshRenderer>();
                    renderer.material = selectedMaterial;

                    _lastTarget.SetParent(_parent);
                    _lastTarget.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    _lastTarget.GetComponent<MeshRenderer>().material = defaultMaterial;
                    _lastTarget.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            else
            {
                _lastTarget.GetComponent<MeshRenderer>().material = defaultMaterial;
                _lastTarget.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        else
        {
            if (_lastTarget)
            {
                _lastTarget.parent = null;
                _lastTarget.GetComponent<MeshRenderer>().material = defaultMaterial;
                _lastTarget.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public void PlaceTower()
    {
        var position = crosshair.transform.position;
        // position.y += 0.05f;
        GameObject newTower = Instantiate(towerPrefab, position, new Quaternion(0, crosshair.transform.rotation.y, 0, 1));
        _gameOverTrigger = newTower.GetComponentInChildren<GameOverTrigger>();
        Invoke(nameof(EnableGameOver), 2.0f);
    }

    void EnableGameOver()
    {
        _gameOverTrigger.canLose = true;
    }

    void CrosshairCalculation()
    {
        Ray ray = _arCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (_raycastManager.Raycast(ray, _hits))
        {
            _pose = _hits[0].pose;
            crosshair.transform.position = _pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }

    public void ClearField()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tower in towers)
        {
            Destroy(tower);
        }

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }

        _gameOverTrigger.canLose = false;
        _gameOverTrigger.gameOverText.enabled = false;
        _gameOverTrigger.playAgainButton.enabled = false;
        _gameOverTrigger.playAgainImage.enabled = false;

    }
}
