using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Target;

    int speed;

    private SpriteRenderer spr;
    [SerializeField]
    private Sprite Circle;


    void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("EndingText");
        Player.transform.position = new Vector3(0f, Player.transform.position.y, Player.transform.position.z);
        Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    void Update()
    {
        speed += 1;
        Player.transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        Player.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime);

        if (Player.transform.position.y >= 200)
        {
            spr.sprite = Circle;
        }


    }
    IEnumerator EndingText()
    {
        yield return new WaitForSeconds(5f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("finally...");

        yield return new WaitForSeconds(5f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("I'm a Star!");

        yield return new WaitForSeconds(6f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("...?!");

        
        yield return new WaitForSeconds(5.5f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("I'm a Circle!");

        yield return new WaitForSeconds(3f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("...Umm");

        yield return new WaitForSeconds(3f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("Circle...");

        yield return new WaitForSeconds(3f);

        GameObject.Find("PlayerText").GetComponent<PlayerText>().BroadcastText("rather Good!");
    }
    



}
