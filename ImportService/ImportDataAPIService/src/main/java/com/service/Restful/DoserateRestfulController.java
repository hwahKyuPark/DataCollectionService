package com.service.Restful;

import com.google.gson.Gson;
import com.service.Model.Doserate;
import com.service.Model.TestModel;
import com.service.Repository.DoserateRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.*;

import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 * Created by user on 2019-03-26.
 */
@RestController
@RequestMapping("/doserate")
public class DoserateRestfulController {

    @Autowired
    private DoserateRepository doserateRepository;

    @RequestMapping(value ="/save", method = RequestMethod.POST, produces = "application/json", consumes = "application/json")
    public void TestApi(@RequestBody Doserate  dataList)
    {
        for(int i=0 ; i< dataList.getDataList().size(); i++)
        {
            if(doserateRepository.findByApiOfferAndApiNameAndApiOfferTime(
                    dataList.getDataList().get(i).apiOffer,
                    dataList.getDataList().get(i).apiName,
                    dataList.getDataList().get(i).apiOfferTime).isEmpty() == true)
            {
                long time = System.currentTimeMillis();
                SimpleDateFormat dayTime = new SimpleDateFormat("yyyy-mm-dd hh:mm:ss");
                String str = dayTime.format(new Date(time));

                doserateRepository.save(dataList.getDataList().get(i));

                System.out.println("DB 저장: \t\t"+ dataList.getDataList().get(i).apiOfferTime+"\t\t ~~ \t\t "+dataList.getDataList().get(i).apiName
                        + "\t\t\t\t현재시간: \t\t" + str);
            }

            else
                System.out.println(dataList.getDataList().get(i).apiName +
                        "\t\t\t\t 나가 이새끼야!!!!!! 중복이다..." +"\t\t\t\t\t\t\t\t [" + dataList.getDataList().get(i).apiOfferTime + "]" );
        }
    }

    @RequestMapping(value = "/findAll",method = RequestMethod.GET, produces = "application/json")
    public String FindAllDoserate(){
        Gson gson = new Gson();
        String strJson = gson.toJson(doserateRepository.findAll());

        System.out.println(strJson);
        System.out.println(doserateRepository.findAll());

        return strJson;
    }

    @RequestMapping(value = "/findAllByApiKey/{apikey}", method = RequestMethod.GET, produces = "application/json")
    public String FindByAPIKey(@PathVariable String apikey){
        Gson gson = new Gson();
        String strJson = gson.toJson(doserateRepository.findAllByApiKey(apikey));

        System.out.println(strJson);
        System.out.println(doserateRepository.findAllByApiKey(apikey));

        return "test";
    }

    @RequestMapping(value = "/findByApiOffer/{apioffer}", method = RequestMethod.GET)
    public List <Doserate> FindByApiOfferList(@PathVariable String apioffer){

        return doserateRepository.findByApiOffer(apioffer);
    }

    @RequestMapping(value = "/deleteAll", method = RequestMethod.DELETE, produces = "application/json")
    public void DeleteAllDoserate(){

        doserateRepository.deleteAll();
    }
}
