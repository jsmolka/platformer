using UnityEngine;

public static partial class Extensions
{
    public static bool IsPlayer(this Collider collider)
    {
        return collider.tag == "Player";
    }

    public static bool IsEnemy(this Collider collider)
    {
        return collider.tag == "Enemy";
    }
}
