using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace UniRxWorkBook
{
    public class Lesson_13_DistinctUntilChanged : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private Text statusText;

        private void Start()
        {
            var controller = target.GetComponent<CharacterController>();

            /*
            객체가 착지하거나 이륙한 타이밍을 감지하여 화면에 표시하고 싶습니다
            ____를 수정하여, isGrounded가 true에서 false로 변경되거나 false에서 true로 변경된 순간을 감지하도록 해보세요
            */

            this.UpdateAsObservable()
                .Select(_ => controller.isGrounded)
                .Throttle(TimeSpan.FromMilliseconds(5))
                .Subscribe(isGrounded => StatusOutput(isGrounded));
        }

        #region Output
        private List<string> logList = new List<string>();
        private int maxLogLength = 20;

        /// <summary>
        /// 착륙 또는 이륙 상태를 문자열로 변환하여 표시합니다
        /// </summary>
        /// <param name="isGrounded"></param>
        private void StatusOutput(bool isGrounded)
        {
            var text = isGrounded ? "OnGrounded\n" : "OnJumped\n";
            AddLog(text);
            statusText.text = logList.Aggregate((p, c) => p + c);
        }

        /// <summary>
        /// 로그 텍스트를 맨 앞에 추가하기
        /// </summary>
        private void AddLog(string text)
        {
            logList.Insert(0,text);
            if (logList.Count > maxLogLength) logList.RemoveAt(maxLogLength);
        }
        #endregion
    }
}