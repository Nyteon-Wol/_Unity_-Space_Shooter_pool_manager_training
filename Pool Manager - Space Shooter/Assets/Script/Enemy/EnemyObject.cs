using UnityEngine;

[CreateAssetMenu(fileName = "enemyStats", menuName = "Enemy/Ghost")]
public class EnemyObject : ScriptableObject
{
    public string EnemyName;
    public float speed;
}
