using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

namespace UniRxWorkBook.Operators
{
    public class Lesson_3_SkipUntil : MonoBehaviour
    {
        private void Start()
        {
            //마우스 클릭 스트림
            var clickStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
            
            //_____() 부분을 올바른 형식으로 대체하여, 마우스 클릭이 한 번이라도 발생하면 회전이 시작되도록 만들어보세요.
            this.UpdateAsObservable()
                .SkipUntil(clickStream)
                .Subscribe(_ => RotateCube());
        }

        private void RotateCube()
        {
            this.transform.rotation = Quaternion.AngleAxis(1.0f, Vector3.up) * this.transform.rotation;
        }
    }
}