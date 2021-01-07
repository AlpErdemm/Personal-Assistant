using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IDragHandler
{
    [SerializeField] GameObject tasksPanel;

    public float maxY;
    public float minY;

    public void OnDrag(PointerEventData eventData)
    {
        float force = -eventData.delta.y;

        if(tasksPanel.transform.localPosition.y > maxY)
        {
            if (force < 0){
                tasksPanel.transform.Translate(new Vector3(0, force, 0));
            }
        }
        else if (tasksPanel.transform.localPosition.y < minY)
        {
            if (force > 0)
            {
                tasksPanel.transform.Translate(new Vector3(0, force, 0));
            }
        }
        else
        {
            tasksPanel.transform.Translate(new Vector3(0, force, 0));
        }
    }
}
