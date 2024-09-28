import { Body, Controller, Delete, Get, Param, Post, Put, UseInterceptors } from '@nestjs/common';
import { Customer } from '../models/customer.model';
import { Result } from '../models/result.model';
import { CreateCustomerContract } from '../contracts/customer.contracts';
import { ValidatorInterceptor } from 'src/interceptors/validator.interceptor';

// localhost:3000/v1/customers
@Controller('v1/customers')
export class CustomerController {
  @Get()
  get() {
    return new Result('', true, [], null);
  }

  @Get(':document')
  getById(@Param('document') document: string) {
    return new Result('', true, {}, null);
  }

  @Post()
  @UseInterceptors(new ValidatorInterceptor(new CreateCustomerContract()))
  post(@Body() body: Customer) {
    return new Result('Cliente criado com sucesso', true, body, null);
  }

  @Put(':document')
  put(@Param('document') document, @Body() body) {
    return new Result('Cliente alterado com sucesso', true, body, null);
  }

  @Delete(':document')
  delete(@Param('document') document) {
    return new Result('Cliente removido com sucesso', true, null, null);
  }
}
