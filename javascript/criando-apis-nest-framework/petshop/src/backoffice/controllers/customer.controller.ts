import { Body, Controller, Delete, Get, HttpException, HttpStatus, Param, Post, Put, UseInterceptors } from '@nestjs/common';
import { Result } from '../models/result.model';
import { CreateCustomerContract } from '../contracts/customer.contracts';
import { ValidatorInterceptor } from 'src/interceptors/validator.interceptor';
import { CreateCustomerDto } from '../dtos/create-customer-dto';
import { AccountService } from '../services/account.service';
import { User } from '../models/user.model';
import { CustomerService } from '../services/customer.service';
import { Customer } from '../models/customer.model';

// localhost:3000/v1/customers
@Controller('v1/customers')
export class CustomerController {
  constructor(
    private readonly accountService: AccountService,
    private readonly customerService: CustomerService
  ) {}

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
  async post(@Body() model: CreateCustomerDto) {
    try {
      const user = await this.accountService.create(new User(model.name, model.password, true));
      const customer = new Customer(model.name, model.document, model.email, null, null, null, null, user);
      const result = await this.customerService.create(customer);
      return new Result('Cliente criado com sucesso', true, result, null);
    } catch (error) {
      return new HttpException(new Result('Não foi possível realizar seu cadastro', false, null, error), HttpStatus.BAD_REQUEST);
    }
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
