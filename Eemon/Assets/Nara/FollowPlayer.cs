using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    Deer deer;  // 変数名を小文字の 'deer' に変更して、クラス名と区別

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        // "Deer" タグが付いている GameObject から Deer コンポーネントを取得
        GameObject deerObject = GameObject.FindWithTag("Deer");
        if (deerObject != null) {
            deer = deerObject.GetComponent<Deer>();
        }

        if (deer == null) {
            Debug.LogError("Deer component not found on any GameObject with 'Deer' tag.");
        }
    }

    // Update is called once per frame
    void Update () {
        if (deer != null && deer.CanWalk) {
            // プレイヤーの方に向かって移動する
            agent.destination = player.transform.position;
        } else {
            // 移動を停止
            agent.isStopped = true;
        }
    }
}