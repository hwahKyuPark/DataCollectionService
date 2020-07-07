package com.service.Repository;

import com.service.Model.Doserate;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

/**
 * Created by user on 2019-04-03.
 */
public interface DoserateRepository extends MongoRepository<Doserate, String> {
    public Doserate findAllByApiKey(String name);
    public List <Doserate> findByApiOffer(String apiOffer);
    public List <Doserate> findByApiOfferAndApiNameAndApiOfferTime(String apiOffer, String apiName, String apiOfferTime);
}
