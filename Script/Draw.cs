using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public LineRenderer line;
    public GameObject LineObject;
    private GameObject Line;
    public Transform LineFather;
    private List<Vector3>pos=new List<Vector3>();
    Ray ray;
    RaycastHit hit;
    public Texture2D curTe;
    private void OnMouseDown()
    {
        if(LineObject != null)
        {
            Line = Instantiate(LineObject, LineFather);
            Line.name = "Line";
            line = Line.GetComponent<LineRenderer>();
            line.positionCount = 0;
            Cursor.SetCursor(curTe, new Vector2(20, 180), CursorMode.Auto);
        }

    }

    private void OnMouseDrag()
    {
                if(!pos.Contains(GetHitPos())&& GetHitPos()!=Vector3.zero&&line)
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, GetHitPos());
                    pos.Add(GetHitPos());
                }
    }
    private void OnMouseUp()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    private Vector3 GetHitPos()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Note"))
            {
                return hit.point;
            }
        }
        return Vector3.zero;
    }
    public void ClearLine()
    {
        for(int i=0;i<LineFather.childCount;i++)
        {
            Destroy(LineFather.GetChild(i).gameObject);
        }

    }
    public void Return()
    {
        ClearLine();
        gameObject.SetActive(false);

    }
}
