import { Module } from '@nestjs/common';
import { CustomerController } from './controllers/customer.controller';
import { UserSchema } from './schemas/user.schema';
import { CustomerSchema } from './schemas/customer.schema';
import { MongooseModule } from '@nestjs/mongoose';
import { AccountService } from './services/account.service';
import { CustomerService } from './services/customer.service';

@Module({
  imports: [
    MongooseModule.forFeature([
      {
        name: 'Customer',
        schema: CustomerSchema,
      },
      {
        name: 'User',
        schema: UserSchema,
      }
    ])
  ],
  controllers: [CustomerController],
  providers: [AccountService, CustomerService],
})
export class BackofficeModule {}
