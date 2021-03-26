using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(range, range);
        EventMan.Instance.MouseClickOff += HideRange;
    }

    public void ShowRange()
    {
        sp.enabled = true;
    }

    public void HideRange()
    {
        sp.enabled = false;
    }

    public void OnDestroy()
    {
        EventMan.Instance.MouseClickOff -= HideRange;
    }
}
