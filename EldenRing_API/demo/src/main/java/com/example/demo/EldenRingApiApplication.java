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
/*
	@Bean
	CommandLineRunner runner(WeaponRepository weaponRepository)
	{
		return ags -> {

			Weapon weapon1 = new Weapon(
					"Rüdigirs Reudiger Rock",
					"link:...",
					"abc",
					Arrays.asList(
							new Attribute("Phy", 100),
							new Attribute("Mag", 0),
							new Attribute("Fire", 5),
							new Attribute("Lightning", 12),
							new Attribute("Holy", 0),
							new Attribute("Crit", 150)),
					Arrays.asList(
							new Attribute("Phy", 110),
							new Attribute("Mag", 0),
							new Attribute("Fire", 0),
							new Attribute("Lightning", 0),
							new Attribute("Holy", 50),
							new Attribute("Boost", 130)),
					Arrays.asList(
							new Scaling("Str", "S"),
							new Scaling("Dex", "A")),
					Arrays.asList(
							new Attribute("Str", 25),
							new Attribute("Dex", 20)),
					"Axe",
					22.5F
			);
			weaponRepository.insert(weapon1);
		};

	}*/
}
