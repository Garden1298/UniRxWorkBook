using System;
using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace UniRxWorkBook.StreamSources
{
    public class Lesson_5_ReactiveProperty : MonoBehaviour
    {
        [SerializeField] private Text subscribeText; //RP를 Subscribe한 결과를 표시합니다
        [SerializeField] private Text updateText; //Update 내에서 RP를 감시하고 표시합니다
        [SerializeField] private Text toReactivePropertyText; //스트림을 RP로 변환하여 표시합니다

        // ReactiveProperty(이하 RP)은 일반 변수에 Subject의 기능을 추가한 것입니다.
        // 다시 말해, "Subscribe할 수 있는 변수"입니다. 동작적으로는 BehaviorSubject와 유사합니다.
        //
        // RP에는 Value라는 속성이 제공되어 있으며, 이 Value에 값을 할당함으로써 OnNext를 발행할 수 있습니다.
        // 또한, 이 Value는 Subscribe 없이도 값을 액세스할 수 있습니다 (즉, Subscribe하지 않고도 일반 변수처럼 읽을 수 있음).
        private ReactiveProperty<int> reactiveProperty = new ReactiveProperty<int>(0);

        private void Start()
        {
            //RP를 Subscribe하고 subscribeText에 반영하는 예제
            reactiveProperty.Subscribe(value => subscribeText.text = value.ToString());

            //-------------------

            //RP의 Value를 매 프레임 읽어서 updateText에 반영하는 예제
            this.UpdateAsObservable().Subscribe(_ =>
            {
                //RP의 Value 속성을 통해 언제든지 최신 값을 가져올 수 있습니다.
                updateText.text = reactiveProperty.Value.ToString();
            });

            //-------------------

            //다른 스트림을 ReactiveProperty로 변환하는 예제
            var interbalRP
                = Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(1)) //1초마다 카운트 업하는 예제
                    .ToReactiveProperty(0); //RP로 변환 (초기값은 0)
            interbalRP.Subscribe(value => toReactivePropertyText.text = value.ToString())
                .AddTo(this); //GameObject 파괴 시 Dispose하는 예제

            //-------------------

            //RP의 업데이트 시작
            StartCoroutine(CountUpCoroutine());
        }

        //RP를 1초마다 업데이트하여 (카운트 업)
        private IEnumerator CountUpCoroutine()
        {
            yield return new WaitForSeconds(1);
            while (true)
            {
                reactiveProperty.Value++;
                yield return new WaitForSeconds(1);
            }
        }
    }
}