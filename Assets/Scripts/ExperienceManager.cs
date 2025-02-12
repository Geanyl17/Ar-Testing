using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private Button addChickenButton;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject chickenPrefab;

    private bool _canAddChicken;
    private GameObject _chickenPreview;
    private Vector3 _detectedPosition = new Vector3();
    private Quaternion _detectedRotation = Quaternion.identity;
    private ARTrackable _currentTrackable;

    public void SetCanAddChicken(bool canAddChicken)
    {
        _canAddChicken = canAddChicken;
        addChickenButton.gameObject.SetActive(!_canAddChicken);
        _chickenPreview.gameObject.SetActive(_canAddChicken);
    }

    private void Start()
    {
        InputHandler.OnTap += SpawnChicken;
        _chickenPreview = Instantiate(chickenPrefab);
        SetCanAddChicken(true);
    }

    private void SpawnChicken()
    {
        if (!_canAddChicken) return;
    
        var chicken = Instantiate(chickenPrefab);
        chicken.GetComponent<Chicken>().PlaceChicken(_currentTrackable);
        chicken.transform.position = _detectedPosition;
        chicken.transform.rotation = _detectedRotation;

        SetCanAddChicken(false);
    }

    private void Update() 
    {
        GetRaycastHitTransform();
    }  

    private void GetRaycastHitTransform()
    {
        var hits = new List<ARRaycastHit>();
        var middleScreen = new Vector2(Screen.width / 2, Screen.height / 2);
        if (raycastManager.Raycast(middleScreen, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon)) //change aaraycastmanager to only raycastmanager
        {
            var hitPose = hits[0].pose;
            _detectedPosition = hitPose.position;
            _detectedRotation = hitPose.rotation;
            _currentTrackable = hits[0].trackable as ARTrackable;
            _chickenPreview.transform.position = _detectedPosition;
            _chickenPreview.transform.rotation = _detectedRotation;
        }
    }




     private void OnDestroy()
    {
        InputHandler.OnTap -= SpawnChicken;
    }


}
