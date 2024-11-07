using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackdelay = 0.5f; // Delay between attacks
    private float lastattacktime = 0.0f; // Track the last attack time
    private int attackCount = 0; // Track the number of attacks
    private Animator attacknimator;

    private void Awake()
    {
        attacknimator = GetComponent<Animator>(); // To get the Animator component
    }

    private void Update()
    {
        // Call the attack handling function
        if (Input.GetKeyDown(KeyCode.J)) // Can change to any key (that is free) to attack
        {
            HandleAttackInput();
        }

        // Reset the attack count after a short period
        if (Time.time - lastattacktime > attackdelay)
        {
            attackCount = 0; // Reset to allow new combo
        }
    }

    public void HandleAttackInput()
    {
        // Check if enough time has passed since last attack
        if (Time.time - lastattacktime > attackdelay)
        {
            attackCount++;
        }
        else
        {
            attackCount = 1; // Reset the count if it exceeds the delay
        }

        Debug.Log("Combo Count: " + attackCount);
        
        lastattacktime = Time.time; // Updates last attack time

        // Trigger the appropriate attack based on attackCount
        switch (attackCount)
        {
            case 1:
                Attack1();
                break;
            case 2:
                Attack2();
                break;
            // Add more cases for additional attacks if needed
        }
    }

    private void Attack1()
    {
        Debug.Log("Attacking 1");
        attacknimator.SetTrigger("attack1"); // Triggers first attack animation
        attacknimator.SetBool("attacking", true);
        Invoke("ResetAttackState", 0.5f); // Adjust based on animation length
    }

    private void Attack2()
    {
        Debug.Log("Attacking 2");
        attacknimator.SetTrigger("attack2"); // Triggers second attack animation
        attacknimator.SetBool("attacking", true);
        Invoke("ResetAttackState", 0.5f); // Adjust based on animation length
    }

    private void ResetAttackState()
    {
        attacknimator.SetBool("attacking", false);
    }
}