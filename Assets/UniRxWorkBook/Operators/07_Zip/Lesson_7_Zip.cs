using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

namespace UniRxWorkBook.Operators
{
    public class Lesson_7_Zip : MonoBehaviour
    {
        [SerializeField]
        private Text resultLabel;
        [SerializeField]
        private Button buttonLeft;
        [SerializeField]
        private Button buttonRight;

        private void Start()
        {
            var rightStream = buttonRight.OnClickAsObservable();
            var leftStream = buttonLeft.OnClickAsObservable();

            // _____를 수정하여, Left와 Right 버튼이 각각 최소한 1회씩 눌렸을 때에만 Text가 변경되도록 만들어보세요.
            leftStream
                .Zip(rightStream, (l, r) => new { l, r })
                .SubscribeToText(resultLabel, _ => "OK");

            // Observable.Zip(leftStream, rightStream)
            //           .SubscribeToText(resultLabel, _ => "OK");
        }

    }
}