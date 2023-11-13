using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

namespace UniRxWorkBook.Operators
{

    public class Answer_Lesson_2_Where : MonoBehaviour
    {

        private void Start()
        {
            // Where 오퍼레이터를 추가함으로써, 특정 조건을 만족할 때만 스트림을 통과시킬 수 있게 됩니다.
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButton(0))
                .Subscribe(_ => RotateCube());
        }

        private void RotateCube()
        {
            this.transform.rotation = Quaternion.AngleAxis(1.0f, Vector3.up)*this.transform.rotation;
        }
    }
}
