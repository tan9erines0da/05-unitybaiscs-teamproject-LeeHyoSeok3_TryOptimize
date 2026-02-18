using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanZBlock : MonoBehaviour
{
    [SerializeField] CangenerateBolockList _board;
    private GridTile _this;
    CanZBlock _down;
    CanZBlock _left;
    CanZBlock _right;
    CanZBlock _up;
    

    void Awake()
    {
        _this = GetComponent<GridTile>();
    }
    void Start()
    {
        _down = _this._downBlock.GetComponent<CanZBlock>();
        _left = _this._leftBlock.GetComponent<CanZBlock>();
        _right = _this._rightBlock.GetComponent<CanZBlock>();
        _up = _this._upBlock.GetComponent<CanZBlock>();
        
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
            !_this._leftBlock.OnPre() &&
            !_this._downBlock.OnPre() &&
            !_this._downBlock._rightBlock.OnPre() )
        {
            // _board 리스트와 딕셔너리에 그리드 추가하기
            _board.AddList(_this, _board.ZUpList, _board.ZupIndex);
        }
        else
        {
            // RemoveList
            _board.RemoveList(_this, _board.ZUpList, _board.ZupIndex);
        }
    }
    void CanRight()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._leftBlock.OnPre() &&
            !_this._upBlock.OnPre() &&
            !_this._downBlock._leftBlock.OnPre() )
        {
            _board.AddList(_this, _board.ZRightList, _board.ZrightIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.ZRightList, _board.ZrightIndex);
        }
    }
    void CanDown()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._upBlock.OnPre() &&
            !_this._rightBlock.OnPre() &&
            !_this._upBlock._leftBlock.OnPre() )
        {
            // Down에서 _this를 Add
            _board.AddList(_this, _board.ZDownList, _board.ZdownIndex);
        }
        else
        {
            _board.RemoveList(_this, _board.ZDownList, _board.ZdownIndex);
        }
    }
    void CanLeft()
    {
        //가능성 판독
        if( !_this.OnPre() && 
            !_this._downBlock.OnPre() &&
            !_this._rightBlock.OnPre() &&
            !_this._upBlock._rightBlock.OnPre() )
        {
            //리스트에 업
            _board.AddList(_this, _board.ZLeftList, _board.ZleftIndex);
        }
        else
        {
            //리스트에서 해제
            _board.RemoveList(_this, _board.ZLeftList, _board.ZleftIndex);
        }
    }
}
