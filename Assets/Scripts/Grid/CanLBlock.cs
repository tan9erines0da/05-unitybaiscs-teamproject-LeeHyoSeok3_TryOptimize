using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanLBlock : MonoBehaviour

{
    [SerializeField] CangenerateBolockList _board;
    private GridTile _this;
    CanLBlock _down;
    CanLBlock _left;
    CanLBlock _right;
    CanLBlock _up;
    

    void Awake()
    {
        _this = GetComponent<GridTile>();
    }
    void Start()
    {
        _down = _this._downBlock.GetComponent<CanLBlock>();
        _left = _this._leftBlock.GetComponent<CanLBlock>();
        _right = _this._rightBlock.GetComponent<CanLBlock>();
        _up = _this._upBlock.GetComponent<CanLBlock>();
        
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
            !_this._upBlock.OnPre() &&
            !_this._downBlock.OnPre() &&
            !_this._rightBlock._downBlock.OnPre() )
        {
            _board.AddList(_this, _board.JUpList, _board.JupIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.JUpList, _board.JupIndex);
        }
    }
    void CanRight()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._leftBlock.OnPre() &&
            !_this._rightBlock.OnPre() &&
            !_this._leftBlock._downBlock.OnPre() )
        {
            _board.AddList(_this, _board.JRightList, _board.JrightIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.JRightList, _board.JrightIndex);
        }
    }
    void CanDown()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._downBlock.OnPre() &&
            !_this._upBlock.OnPre() &&
            !_this._upBlock._leftBlock.OnPre() )
        {
            _board.AddList(_this, _board.JDownList, _board.JdownIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.JDownList, _board.JdownIndex);
        }
    }
    void CanLeft()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._leftBlock.OnPre() &&
            !_this._rightBlock.OnPre() &&
            !_this._rightBlock._upBlock.OnPre() )
        {
            //리스트에 업
            _board.AddList(_this, _board.JLeftList, _board.JleftIndex);
        }
        else
        {
            //리스트에서 해제
            _board.RemoveList(_this, _board.JLeftList, _board.JleftIndex);
        }
    }
}
