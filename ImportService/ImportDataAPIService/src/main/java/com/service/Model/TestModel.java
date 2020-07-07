package com.service.Model;

import org.springframework.data.mongodb.core.mapping.Document;

/**
 * Created by user on 2019-04-19.
 */

public class TestModel {
    private String offer;
    private String keytey;

    public String getOffer() {
        return offer;
    }

    public void setOffer(String offer) {
        this.offer = offer;
    }

    public String getKeytey() {
        return keytey;
    }

    public void setKeytey(String keytey) {
        this.keytey = keytey;
    }
}
