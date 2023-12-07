using UnityEngine;

// The 'Target' class
public class Enemy
{
    public virtual void Attack()
    {
        Debug.Log("The enemy attacks!");
    }
}

// The 'Adapter' class
public class EnemyRobotAdapter : Enemy
{
    private EnemyRobot _enemyRobot;

    // Constructor
    public EnemyRobotAdapter(EnemyRobot enemyRobot)
    {
        _enemyRobot = enemyRobot;
    }

    public override void Attack()
    {
        _enemyRobot.SmashWithHands();
    }
}

// The 'Adaptee' class
public class EnemyRobot
{
    public void SmashWithHands()
    {
        Debug.Log("The enemy robot smashes with its hands!");
    }
}

public class AdapterExample : MonoBehaviour
{
    void Start()
    {
        Enemy enemy = new Enemy();
        EnemyRobot enemyRobot = new EnemyRobot();
        Enemy enemyRobotAdapter = new EnemyRobotAdapter(enemyRobot);

        enemy.Attack();
        enemyRobot.SmashWithHands();
        enemyRobotAdapter.Attack();
    }
}