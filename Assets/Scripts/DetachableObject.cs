using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DetachableObject : MonoBehaviour
{
    private FixedJoint fixedJoint;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        fixedJoint = GetComponent<FixedJoint>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (fixedJoint != null)
            Destroy(fixedJoint);
        
        transform.SetParent(null, true);
    }
}