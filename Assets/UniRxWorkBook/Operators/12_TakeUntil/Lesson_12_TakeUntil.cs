using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace UniRxWorkBook.Operators
{

    public class Lesson_12_TakeUntil : MonoBehaviour
    {
        [SerializeField] private Button onButton;
        [SerializeField] private Button offButton;
        [SerializeField] private GameObject cube;

        private void Start()
        {
            // ____를 수정하여, OFF 버튼을 누르면 회전이 멈추도록 만들어보겠습니다

            var onStream = onButton.OnClickAsObservable();
            var offStream = offButton.OnClickAsObservable();
            

            this.UpdateAsObservable()
                .SkipUntil(onStream)
                .TakeUntil(offStream)
                .RepeatUntilDestroy(gameObject)
                .Subscribe(_ => RotateCube());

        }

        private void RotateCube()
        {
            cube.transform.rotation = Quaternion.AngleAxis(1.0f, Vector3.up) * cube.transform.rotation;
        }
    }
}