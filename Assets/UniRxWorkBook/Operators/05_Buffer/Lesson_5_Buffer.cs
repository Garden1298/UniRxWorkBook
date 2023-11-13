using UnityEngine;
using System.Collections;
using System.Linq;
using UniRx;
using UniRxWorkBook;
using UnityEngine.UI;

namespace UniRxWorkBook.Operators
{
    public class Lesson_5_Buffer : MonoBehaviour
    {
        [SerializeField] private Text resultLabel;
        [SerializeField] private Button buttonA;
        [SerializeField] private Button buttonB;
        [SerializeField] private Button buttonC;

        private void Start()
        {
            var aStream = buttonA.OnClickAsObservable().Select(_ => "A");
            var bStream = buttonB.OnClickAsObservable().Select(_ => "B");
            var cStream = buttonC.OnClickAsObservable().Select(_ => "C");

            // _____()를 수정하여
            // 지난 3번의 눌린 버튼 이력을 표시해 보세요
            // (각각 3번 눌릴 때마다 업데이트되는 형태로 구현해도 좋습니다)
            Observable.Merge(aStream, bStream, cStream)
                .Buffer(3,1)
                .SubscribeToText(resultLabel, x => string.Join(", ",x));

            // IEnmerable<String>를 하나의 String으로 합치려면
            // strings.Aggregate((p, c) => p + c)와 Aggregate를 사용하면 간단하게 작성할 수 있습니다.
        }
    }
}