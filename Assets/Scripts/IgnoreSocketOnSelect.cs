using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class IgnoreSocketOnSelect : MonoBehaviour
{
    [SerializeField] XRBaseInteractor[] _ignoreList;
    [SerializeField] UnityEvent _onSelect;

    public void OnSelectRelay(SelectEnterEventArgs args)
    {
        if (args.interactorObject != null)
        {
            var callOnSelect = true;
            foreach (var item in _ignoreList)
            {
                if ((Object)args.interactorObject == item)
                {
                    callOnSelect = false;
                    break;
                }
            }

            if (callOnSelect)
            {
                _onSelect.Invoke();
            }
        }
    }
}
