package com.example.tsd_app

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView

class MainActivity : AppCompatActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        var btn_hello = findViewById(R.id.bt_helloWorld) as Button
        var txt = findViewById(R.id.tv_helloWorld) as TextView
        var btn_reset = findViewById(R.id.bt_reset) as Button

        btn_hello.setOnClickListener {
            txt.setText("Hello World!")
        }

        btn_reset.setOnClickListener {
            txt.setText("")
        }

    }
}
