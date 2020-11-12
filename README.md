# Animal Rescue in .NET

Find the original animal rescue project [here](https://github.com/spring-cloud-services-samples/animal-rescue).

## API spec (wip)
```
GET /animals
List all animals

POST /animals/{animalId}/adoption-request
 * Create an adoption request for an animal.
 * Requires principal.

PUT /animals/{animalId}/adoption-request/{adoptionRequestId}
 * Update an adoption request for an animal.
 * Requires principal.
 * Requires same principal as on adoption request.
 * Requires animal to exist.
 * Requires animal adoption request to exist.

DELETE /animals/{animalId}/adoption-request/{adoptionRequestId}
 * Delete an adoption request for an animal.
 * Requires principal.
 * Requires animal to exist.
 * Requires animal adoption request to exist.
 * Requires same principal as on adoption request.
```
