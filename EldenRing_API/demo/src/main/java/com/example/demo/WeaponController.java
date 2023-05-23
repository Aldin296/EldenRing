package com.example.demo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
public class WeaponController
{
    @RequestMapping("/home")
    public String serviceTest(){
        return "Das Service funktioniert!";
    }

    @Autowired
    private WeaponService weaponService;

    @RequestMapping("/weapons")
    public List<Weapon> getallWeapons() {
        return weaponService.getallWeapons();
    }


    @RequestMapping("/weapon/{name}")
    public Optional<Weapon> getWeapon(@PathVariable String name) {
        return weaponService.getWeapon(name);
    }

    @RequestMapping(method=RequestMethod.POST, value="/addWeapon")
    public String addWeapon(@RequestBody Weapon weapon) {
        weaponService.addWeapon(weapon);
        String response = "{\"success\": true, \"message\": Weapon has been added successfully.}";
        return response;
    }

    @RequestMapping(method=RequestMethod.PUT, value="/updateWeapon/{name}")
    public String updateWeapon(@RequestBody Weapon weapon, @PathVariable String name) {
        weaponService.updateWeapon(name, weapon);
        String response = "{\"success\": true, \"message\": Weapon has been updated successfully.}";
        return response;
    }


    @DeleteMapping("/deleteWeapon/{name}")
    public String deleteWeapon(@PathVariable String name) {
        weaponService.deleteWeapon(name);
        String response = "{\"success\": true, \"message\": Weapon has been deleted successfully.}";
        return response;
    }
}
