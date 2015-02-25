using UnityEngine;
using System.Collections;

public class ActiveHitables  {

	public static void HitAll(GameObject gameObject){
        var hitables = gameObject.GetComponents(typeof(IHitable));

            if (hitables == null)
                return;

            foreach (IHitable hittable in hitables)
                hittable.Hit();
    }
}
