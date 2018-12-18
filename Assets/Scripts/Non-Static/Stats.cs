using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stats : MonoBehaviour {

    public List<Stat> stats;


    public Stat getStat(string name){
        foreach(Stat stat in stats){
            if (stat.name == name){
                return stat;
            }
        }
        return null;
    }
    public int getStatVal(string name){
        foreach(Stat stat in stats){
            if (stat.name == name){
                if (stat.Val > 0){
                    return stat.Val;
                // } else if (max != -1 && stat.Val > stat.max){
                //     return stat.max;
                } else {
                    return 0;
                }
            }
        }

        return -1;

    }

    public void setStatVal(string name, int val){
        foreach(Stat stat in stats){
            if (stat.name == name){
                stat.Val = val;
            }
        }

    }

    public void Update(){
        foreach(Stat stat in stats){
            stat.effectiveValue = stat.Val;
        }
    }
}
