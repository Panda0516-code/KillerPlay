using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class TargetChange : MonoBehaviour
{
    // 追従対象情報
    [Serializable]
    private struct TargetInfo
    {
        // 追従対象
        public Transform follow;
        // 照準を合わせる対象
        public Transform lookAt;
    }

    // バーチャルカメラ
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    // 追従対象リスト
    [SerializeField] private TargetInfo[] _targetList;

    // 選択中のターゲットのインデックス
    private int _currentTarget = 0;

    // フレーム更新
    private void Start()
    {
        // 追従対象情報が設定されていなければ、何もしない
        if (_targetList == null || _targetList.Length <= 0)
            return;

        // マウスクリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            // 追従対象を順番に切り替え
            if (++_currentTarget >= _targetList.Length)
                _currentTarget = 0;

            // 追従対象を更新
            var info = _targetList[_currentTarget];
            _virtualCamera.Follow = info.follow;
            _virtualCamera.LookAt = info.lookAt;
        }
    }
}
