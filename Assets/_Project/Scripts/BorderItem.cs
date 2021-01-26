using UnityEngine;

public class BorderItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OffScreenWrapper>())
        {
            other.GetComponent<OffScreenWrapper>().HandleEnteringWrapZone();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<OffScreenWrapper>())
        {
            other.GetComponent<OffScreenWrapper>().HandleLeavingWrapZone();
        }
    }
}