using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[���S�̂̊Ǘ����s���Ă���N���X�B
/// �{�^���̐����A�V�C���̎擾����сA�\�������Ă���N���X�B
/// </summary>


[RequireComponent(typeof(GeneratPrefectureButton))]
public class GameManager : MonoBehaviour
{

   

    [Header("�摜�C���[�W��\������ UGUI��Panel��ݒ�")]
    [SerializeField] private Image weatherIcon; //�V�C�A�C�R����\�����邽�߂�Image�R���|�[�l���g


    [SerializeField] private GeneratPrefectureButton generateButton;


    /// <summary>
    /// weatherService�̏�����
    /// WeatherIconManager�̏�����
    /// �{�^���̐���
    /// </summary>
    private void Start() {
        weatherIcon.enabled = false;
        generateButton = GetComponent<GeneratPrefectureButton>();
    }
}

