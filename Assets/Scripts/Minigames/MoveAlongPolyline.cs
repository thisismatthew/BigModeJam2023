using System.Collections;
using System.Collections.Generic;
using Shapes;
using UnityEngine;
using DG.Tweening;

public class MoveAlongPolyline : MonoBehaviour
{
    public Polyline LineToMoveAlong;
    private int index = 0;
    private bool isDoneMoving = true;
    public EmotionDispenser Dispenser;

    public void Move()
    {
        if (!isDoneMoving) return;
        index++;
        if (index > LineToMoveAlong.points.Count-1)
        {
            Dispenser.MinigameResult(true);
            index = 0;
            transform.localPosition = LineToMoveAlong.points[0].point;
            return;
        }
        isDoneMoving = false;
        transform.DOLocalMove(LineToMoveAlong.points[index].point, .2f).onComplete += SetDoneMoving;
    }

    public void SetDoneMoving()
    {
        isDoneMoving = true;
    }


}
