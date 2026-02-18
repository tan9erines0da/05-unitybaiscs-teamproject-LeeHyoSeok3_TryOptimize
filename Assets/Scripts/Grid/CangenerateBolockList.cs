using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CangenerateBolockList : MonoBehaviour
{
    
    public List<GridTile> Grids;
    public List<GridTile> JUpList;
    public List<GridTile> JRightList;
    public List<GridTile> JDownList;
    public List<GridTile> JLeftList;
    public List<GridTile> LUpList;
    public List<GridTile> LRightList;
    public List<GridTile> LDownList;
    public List<GridTile> LLeftList;
    public List<GridTile> OUpList;
    public List<GridTile> ORightList;
    public List<GridTile> ODownList;
    public List<GridTile> OLeftList;
    public List<GridTile> TUpList;
    public List<GridTile> TRightList;
    public List<GridTile> TDownList;
    public List<GridTile> TLeftList;
    public List<GridTile> SUpList;
    public List<GridTile> SRightList;
    public List<GridTile> SDownList;
    public List<GridTile> SLeftList;
    public List<GridTile> ZUpList;
    public List<GridTile> ZRightList;
    public List<GridTile> ZDownList;
    public List<GridTile> ZLeftList;
    public List<GridTile> IUpList;
    public List<GridTile> IRightList;
    public List<GridTile> IDownList;
    public List<GridTile> ILeftList;
    public List<GridTile> ObList;
    
    public Dictionary<GridTile, int> JupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> JdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> JleftIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> JrightIndex = new Dictionary<GridTile, int>();
    
    public Dictionary<GridTile, int> LupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> LrightIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> LdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> LleftIndex = new Dictionary<GridTile, int>();
    
    public Dictionary<GridTile, int> TupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> TdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> TleftIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> TrightIndex = new Dictionary<GridTile, int>();
    
    public Dictionary<GridTile, int> OupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> OdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> OleftIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> OrightIndex = new Dictionary<GridTile, int>();
    
    public Dictionary<GridTile, int> IupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> IdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> IleftIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> IrightIndex = new Dictionary<GridTile, int>();
    
    public Dictionary<GridTile, int> SupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> SdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> SleftIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> SrightIndex = new Dictionary<GridTile, int>();
    
    public Dictionary<GridTile, int> ZupIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> ZdownIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> ZleftIndex = new Dictionary<GridTile, int>();
    public Dictionary<GridTile, int> ZrightIndex = new Dictionary<GridTile, int>();

    void Awake()
    {
    
        ObList = new List<GridTile>(Grids.Count);
        GetNonBlockList();
        
        
        JUpList = new List<GridTile>();
        JRightList = new List<GridTile>();
        JDownList = new List<GridTile>();
        JLeftList = new List<GridTile>();
        LUpList = new List<GridTile>();
        LRightList = new List<GridTile>();
        LDownList = new List<GridTile>();
        LLeftList = new List<GridTile>();
        OUpList = new List<GridTile>();
        ORightList = new List<GridTile>();
        ODownList = new List<GridTile>();
        OLeftList = new List<GridTile>();
        TUpList = new List<GridTile>();
        TRightList = new List<GridTile>();
        TDownList = new List<GridTile>();
        TLeftList = new List<GridTile>();
        SUpList = new List<GridTile>();
        SRightList = new List<GridTile>();
        SDownList = new List<GridTile>();
        SLeftList = new List<GridTile>();
        ZUpList = new List<GridTile>();
        ZRightList = new List<GridTile>();
        ZDownList = new List<GridTile>();
        ZLeftList = new List<GridTile>();
        IUpList = new List<GridTile>();
        IRightList = new List<GridTile>();
        IDownList = new List<GridTile>();
        ILeftList = new List<GridTile>();
    
    }

    void OnEnable()
    {
        GameEventBus.Subscribe<GridUpdateEvent>(CheckAll);
    }
    void OnDisable()
    {
        GameEventBus.Unsubscribe<GridUpdateEvent>(CheckAll);
    }
    void CheckAll(GridUpdateEvent evt)
    {
        GetNonBlockList();
    }
    public void GetNonBlockList()
    {
        ObList.Clear();
        foreach(GridTile grid in Grids)
        {
            if(!(grid._blockOn || grid._predict))
            {
                ObList.Add(grid);
            }
        }
    }
    
    public void AddList(GridTile grid, List<GridTile> list, Dictionary<GridTile, int> indexDic)
    {
        if (indexDic.ContainsKey(grid)) return; // 딕셔너리에 그리드가 키로 이미 있다면 종료 (자기 탐색)
        
        indexDic[grid] = list.Count;  // 리스트 마지막 주소를 딕셔너리의 밸류로 저장
        list.Add(grid);  // 리스트 마지막에 타일 정보 저장
    }

    public bool RemoveList(GridTile grid, List<GridTile> list, Dictionary<GridTile, int> indexDic)
    {
        if (!indexDic.TryGetValue(grid, out int index)) return false; // 딕셔너리에 그리드가 없으면 종료 (자기 탐색)
        
        GridTile last = list[list.Count - 1]; // 리스트 마지막에 있는 그리드 
        
        // 마지막 그리드의 위치를 삭제할 그리드의 위치로 이동
        list[index] =  last;
        indexDic[last] = index;
        
        list.RemoveAt(list.Count - 1); // 리스트에서 제거
        indexDic.Remove(grid); // 딕셔너리에서 제거
        
        return true;
        
    }
}
