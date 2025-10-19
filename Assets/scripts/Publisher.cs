using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using BallMsg = RosMessageTypes.RereDaisha.BallPositionArrayMsg;
using RosMessageTypes.Std;
public class Publisher : MonoBehaviour
{
    private ROSConnection ros;

    // 初期化時に呼ばれる
    void Start()
    {
        // ROSコネクションへのパブリッシャーの登録
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<Int32Msg>("test");
    }

    // フレーム毎に呼ばれる
    void FixedUpdate()
    {
        Int32Msg txdata = new Int32Msg(0);
        ros.Publish("test", txdata);
    }
}