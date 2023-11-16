using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour
{
    private ReactiveProperty<string> messageBox = new ReactiveProperty<string>("");
    public Text messageBoxText;

    private void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => SendMessage("메세지를 보냈다"));

        messageBox.Subscribe(message =>
        {
            messageBoxText.text = message;
        }).AddTo(this);
    }

    private void SendMessage(string message)
    {
        messageBox.Value = $"{message}\n{messageBox.Value}";
    }
}
