using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ���̕��p���擾����N���X
/// </summary>
public class WeatherWind{
    /// <summary>
    /// ��������Ԃ�����
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns></returns>
    public string GetWindDirection(int degrees) {
        string[] direction = 
        {
            "�k"     ,
            "�k�k��" ,
            "�k��"   ,
            "���k��" ,
            "��"     ,
            "���쓌" ,
            "�쓌"   ,
            "��쓌" , 
            "��"     ,
            "��쐼" , 
            "�쐼"   ,
            "���쐼" ,
            "��"     ,
            "���k��" ,
            "�k��"   ,
            "�k�k��"
        };

        /*NOTE : ���ʂ̊��16���ʂƂ��čl�����B
         �k�̊p�x��0�x����n�܂�̂ŁAdegrees�ɁA11.25�x�������Ċp�x�����炷�B
         �����āA22.5�x���ƂɊp�x����؂�A�Ō��16���ʂŏ�Z����ƁA�z��̃C���f�b�N�X�ɊY������index�����܂�B*/
        int index = (int)((degrees + 11.25f) / 22.5f) % 16;
        return direction[index];
    }
}
