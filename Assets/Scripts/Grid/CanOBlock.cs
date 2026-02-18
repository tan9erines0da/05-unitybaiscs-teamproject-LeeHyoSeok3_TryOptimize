using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOBlock : MonoBehaviour
{
    [SerializeField] CangenerateBolockList _board;
    private GridTile _this;
    CanOBlock _down;
    CanOBlock _left;
    CanOBlock _right;
    CanOBlock _up;
    

    void Awake()
    {
        _this = GetComponent<GridTile>();
    }
    void Start()
    {
        _down = _this._downBlock.GetComponent<CanOBlock>();
        _left = _this._leftBlock.GetComponent<CanOBlock>();
        _right = _this._rightBlock.GetComponent<CanOBlock>();
        _up = _this._upBlock.GetComponent<CanOBlock>();
        
        CanUp();
        CanRight();
        CanDown();
        CanLeft();
    }

    public void CheckAll()
    {
        PerformanceMonitor.Instance.BeginMeasure();
        CanUp();
        CanRight();
        CanDown();
        CanLeft();
        PerformanceMonitor.Instance.EndMeasure();
    }

    public void CheckNear()
    {
        _up._up._up._up.CheckAll();
        _up._up._up.CheckAll();
        _up._up._up._left.CheckAll();
        _up._up._up._right.CheckAll();
        _up._up.CheckAll();
        _up._up._left.CheckAll();
        _up._up._left._left.CheckAll();
        _up._up._right.CheckAll();
        _up._up._right._right.CheckAll();
        _up.CheckAll();
        _up._left.CheckAll();
        _up._left._left.CheckAll();
        _up._left._left._left.CheckAll();
        _up._right._right._right.CheckAll();
        _up._right._right.CheckAll();
        _up._right.CheckAll();
        _left.CheckAll();
        _left._left.CheckAll();
        _left._left._left.CheckAll();
        _left._left._left._left.CheckAll();
        CheckAll();
        _right.CheckAll();
        _right._right.CheckAll();
        _right._right._right.CheckAll();
        _right._right._right._right.CheckAll();
        _down._down._down._down.CheckAll();
        _down._down._down.CheckAll();
        _down._down._down._left.CheckAll();
        _down._down._down._right.CheckAll();
        _down._down.CheckAll();
        _down._down._left.CheckAll();
        _down._down._left._left.CheckAll();
        _down._down._right.CheckAll();
        _down._down._right._right.CheckAll();
        _down.CheckAll();
        _down._left.CheckAll();
        _down._left._left.CheckAll();
        _down._left._left._left.CheckAll();
        _down._right._right._right.CheckAll();
        _down._right._right.CheckAll();
        _down._right.CheckAll();
    }
    void CanUp()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._rightBlock.OnPre() &&
            !_this._upBlock.OnPre() &&
            !_this._upBlock._rightBlock.OnPre() )
        {
            _board.AddList(_this, _board.OUpList, _board.OupIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.OUpList, _board.OupIndex);
        }
    }
    void CanRight()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._rightBlock.OnPre() &&
            !_this._downBlock.OnPre() &&
            !_this._downBlock._rightBlock.OnPre() )
        {
            _board.AddList(_this, _board.ORightList, _board.OrightIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.ORightList, _board.OrightIndex);
        }
    }
    void CanDown()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._downBlock.OnPre() &&
            !_this._leftBlock.OnPre() &&
            !_this._downBlock._leftBlock.OnPre() )
        {
            _board.AddList(_this, _board.ODownList, _board.OdownIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.ODownList, _board.OdownIndex);
        }
    }
    void CanLeft()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._upBlock.OnPre() &&
            !_this._leftBlock.OnPre() &&
            !_this._upBlock._leftBlock.OnPre() )
        {
            //리스트에 업
            _board.AddList(_this, _board.OLeftList, _board.OleftIndex);
        }
        else
        {
            //리스트에서 해제
            _board.RemoveList(_this, _board.OLeftList, _board.OleftIndex);
        }
    }
}
