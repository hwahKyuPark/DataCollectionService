package com.service.Model;

import org.springframework.data.mongodb.core.mapping.Document;

import java.util.ArrayList;

/**
 * Created by user on 2019-04-03.
 */

@Document(collection = "doserate")
public class Doserate {

    public String apiOffer;
    public String apiKey;
    public String apiName;
    public double doserateValue;
    public String unit;
    public String apiOfferTime;
    public String dbUpdateTime;

    public ArrayList<Doserate> dataList;

    public String getApiOffer() {
        return apiOffer;
    }

    public void setApiOffer(String apiOffer) {
        this.apiOffer = apiOffer;
    }

    public String getApiKey() {
        return apiKey;
    }

    public void setApiKey(String apiKey) {
        this.apiKey = apiKey;
    }

    public String getApiName() {
        return apiName;
    }

    public void setApiName(String apiName) {
        this.apiName = apiName;
    }

    public double getDoserateValue() {
        return doserateValue;
    }

    public void setDoserateValue(double doserateValue) {
        this.doserateValue = doserateValue;
    }

    public String getUnit() {
        return unit;
    }

    public void setUnit(String unit) {
        this.unit = unit;
    }

    public String getApiOfferTime() {
        return apiOfferTime;
    }

    public void setApiOfferTime(String apiOfferTime) {
        this.apiOfferTime = apiOfferTime;
    }

    public String getApiUpdateTime() {
        return dbUpdateTime;
    }

    public void setApiUpdateTime(String dbUpdateTime) {
        this.dbUpdateTime = dbUpdateTime;
    }

    public ArrayList<Doserate> getDataList() {
        return dataList;
    }

    public void setDataList(ArrayList<Doserate> dataList) {
        this.dataList = dataList;
    }

    @Override
    public String toString() {
        return "Doserate{" +
                "apiOffer='" + apiOffer + '\'' +
                ", apiKey='" + apiKey + '\'' +
                ", apiName='" + apiName + '\'' +
                ", doserateValue=" + doserateValue +
                ", unit='" + unit + '\'' +
                ", apiOfferTime='" + apiOfferTime + '\'' +
                ", apiUpdateTime='" + dbUpdateTime + '\'' +
                ", dataList=" + dataList +
                '}';
    }
}
