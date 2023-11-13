using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

namespace UniRxWorkBook.Operators
{

    public class Lesson_2_Where : MonoBehaviour
    {

        private void Start()
        {
            // _____() 부분을 올바른 형식으로 대체하여, 마우스의 왼쪽 클릭을 하는 동안에만 Cube가 회전하도록 만들어보세요.
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButton(0))
                .Subscribe(_ => RotateCube());
        }

        private void RotateCube()
        {
            this.transform.rotation = Quaternion.AngleAxis(1.0f, Vector3.up) * this.transform.rotation;
        }

    }
}
