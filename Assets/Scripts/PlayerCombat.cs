using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform Player1AtkPoint;
    public float AtkRange = 0.5f;

    public LayerMask NonPlayer1Layers;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }
    void Attack()
    {
        // Animación
        // Todo

        // Hitboxes
        Collider2D[] HitPlayers = Physics2D.OverlapCircleAll(Player1AtkPoint.position, AtkRange, nonPlayer1Layers);

        // Daño
        foreach(Collider2D enemy in HitPlayers)
        {
            Debug.Log("Pegado");
        }
    }
}
