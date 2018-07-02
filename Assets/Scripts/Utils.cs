using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static Vector3 Lerp(Vector3 start, Vector3 end, float percent) {
        //    return(y1*(1-mu)+y2*mu);

        float x = start.x * (1 - percent) + end.x * percent;
        float y = start.y * (1 - percent) + end.y * percent;
        float z = start.z * (1 - percent) + end.z * percent;

        return new Vector3(x,y,z);
    }
}
