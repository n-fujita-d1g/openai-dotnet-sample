<template>
  <v-container>
    <v-row>
      <v-col>
        <v-text-field v-model="input" placeholder="Prompt" outlined></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-btn @click="onSubmit">Submit</v-btn>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-progress-circular
          v-show="loading"
          indeterminate
          color="primary"
        ></v-progress-circular>
        <div v-html="result"></div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { defineComponent } from 'vue';
import axios from 'axios'

export default defineComponent({
  name: 'HomeView',

  data: () => ({
    input: '',
    result: '',
    loading: false
  }),

  methods: {
    onSubmit() {
      const input = this.input
      const model = 4
      const maxTokens = 200
      this.result = ''
      this.loading = true
      axios.post('/api/generate', { input, model, maxTokens }).then((res) => {
        this.result = res.data.result.split(/\n/).join('<br>')
      }).finally(() => {
        this.loading = false
      })
    }
  }
});
</script>
