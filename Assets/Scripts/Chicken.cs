using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Chicken : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    public void PlaceChicken([CanBeNull]ARTrackable trackableParent)
    {
        transform.SetParent(trackableParent?.transform);
        animator.SetBool("IsAwake", true);
    }
}
