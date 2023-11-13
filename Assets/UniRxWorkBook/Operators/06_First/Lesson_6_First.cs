using UnityEngine;
using System.Collections;
using System.Linq;
using UniRx;
using UnityEngine.UI;

namespace UniRxWorkBook.Operators
{
    public class Lesson_6_First : MonoBehaviour
    {

        [SerializeField]
        private Text resultLabel;
        [SerializeField]
        private Button buttonA;
        [SerializeField]
        private Button buttonB;
        [SerializeField]
        private Button buttonC;

        private void Start()
        {
            var aStream = buttonA.OnClickAsObservable().Select(_ => "A");
            var bStream = buttonB.OnClickAsObservable().Select(_ => "B");
            var cStream = buttonC.OnClickAsObservable().Select(_ => "C");

            // _____를 수정하여, 처음 1회 눌릴 때만 Text가 변경되도록 만들어보세요.
            Observable.Merge(aStream, bStream, cStream)
                .First()
                .SubscribeToText(resultLabel);
        }

    }
}