using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

namespace UniRxWorkBook.Operators
{
    public class Lesson_4_Skip : MonoBehaviour
    {
        private void Start()
        {
            // _____() 부분을 올바른 형식으로 대체하여, 마우스가 3번 클릭되면 Cube가 회전하도록 만들어보세요.
            var clickStream = this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0));

            this.UpdateAsObservable()
                .SkipUntil(clickStream.Skip(2))
                .Subscribe(_ => RotateCube());
        }

        private void RotateCube()
        {
            this.transform.rotation = Quaternion.AngleAxis(1.0f, Vector3.up) * this.transform.rotation;
        }
    }
}
