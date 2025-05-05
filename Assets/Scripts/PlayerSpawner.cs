using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player;
    public Transform[] spawnPoints;
    public float spawnPointRadius = 5;
    private int playerCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int gamepadIndex = 0;

        // Spawnear primer jugador con teclado (si existe)
        if (Keyboard.current != null)
        {
            SpawnPlayer(Keyboard.current, spawnPoints[playerCount]);
        }

        // Spawnear jugadores por cada gamepad conectado
        foreach (var gamepad in Gamepad.all)
        {
            if (spawnPoints.Length > playerCount)
            {
                SpawnPlayer(gamepad, spawnPoints[playerCount]);
                gamepadIndex++;
            }
        }
    }
    void SpawnPlayer(InputDevice device, Transform spawnPoint)
    {
        GameObject newPlayer = Instantiate(Player, spawnPoint.position, Quaternion.identity);

        // Vincular el input del jugador a su dispositivo
        var playerInput = newPlayer.GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.SwitchCurrentControlScheme(device);
            playerInput.defaultControlScheme = device is Keyboard ? "Keyboard" : "Gamepad";
        }

        // Asignar número de jugador al animador
        var animator = newPlayer.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetInteger("PlayerNum", playerCount);
        }

        playerCount++;
    }

    // Visualizar donde spawnean los jugadores en el editor
    private void OnDrawGizmos()
    {
        foreach (Transform SpawnPoint in spawnPoints)
        {
            Gizmos.DrawWireSphere(SpawnPoint.position, spawnPointRadius);
        }
    }
}