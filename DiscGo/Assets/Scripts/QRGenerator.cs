﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;

public class QRGenerator : MonoBehaviour {
    public RawImage rawImage;

    public void GenerateQR(string text) {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        rawImage.texture = encoded;
    }

    private static Color32[] Encode(string textForEncoding, int width, int height) {
        var writer = new BarcodeWriter {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
}