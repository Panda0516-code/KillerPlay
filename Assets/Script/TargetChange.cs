using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class TargetChange : MonoBehaviour
{
    // �Ǐ]�Ώۏ��
    [Serializable]
    private struct TargetInfo
    {
        // �Ǐ]�Ώ�
        public Transform follow;
        // �Ə������킹��Ώ�
        public Transform lookAt;
    }

    // �o�[�`�����J����
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    // �Ǐ]�Ώۃ��X�g
    [SerializeField] private TargetInfo[] _targetList;

    // �I�𒆂̃^�[�Q�b�g�̃C���f�b�N�X
    private int _currentTarget = 0;

    // �t���[���X�V
    private void Start()
    {
        // �Ǐ]�Ώۏ�񂪐ݒ肳��Ă��Ȃ���΁A�������Ȃ�
        if (_targetList == null || _targetList.Length <= 0)
            return;

        // �}�E�X�N���b�N���ꂽ��
        if (Input.GetMouseButtonDown(0))
        {
            // �Ǐ]�Ώۂ����Ԃɐ؂�ւ�
            if (++_currentTarget >= _targetList.Length)
                _currentTarget = 0;

            // �Ǐ]�Ώۂ��X�V
            var info = _targetList[_currentTarget];
            _virtualCamera.Follow = info.follow;
            _virtualCamera.LookAt = info.lookAt;
        }
    }
}
