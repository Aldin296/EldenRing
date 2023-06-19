package com.example.demo;

import com.mongodb.client.MongoClient;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.data.mongodb.repository.config.EnableMongoRepositories;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.List;

@SpringBootApplication
@EnableMongoRepositories
public class EldenRingApiApplication
{
	public static void main(String[] args) {
		SpringApplication.run(EldenRingApiApplication.class, args);
	}

}
