using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJBlock : MonoBehaviour
{
    [SerializeField] CangenerateBolockList _board;
    private GridTile _this;
    CanJBlock _down;
    CanJBlock _left;
    CanJBlock _right;
    CanJBlock _up;
    

    void Awake()
    {
        _this = GetComponent<GridTile>();
    }
    void Start()
    {
        _down = _this._downBlock.GetComponent<CanJBlock>();
        _left = _this._leftBlock.GetComponent<CanJBlock>();
        _right = _this._rightBlock.GetComponent<CanJBlock>();
        _up = _this._upBlock.GetComponent<CanJBlock>();
        
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
        if(!_this.OnPre() && 
           !_this._upBlock.OnPre() &&
           !_this._downBlock.OnPre() &&
           !_this._leftBlock._downBlock.OnPre() )
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
            !_this._rightBlock.OnPre() &&
            !_this._leftBlock.OnPre() &&
            !_this._upBlock._leftBlock.OnPre() 
            )
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
            !_this._upBlock._rightBlock.OnPre() &&
            !_this._upBlock.OnPre() )
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
            !_this._rightBlock._downBlock.OnPre() )
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
